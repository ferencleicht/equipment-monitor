"use server";

import { SendMessageCommand, SQSClient } from "@aws-sdk/client-sqs";
import { redirect } from "next/navigation";
import { z } from "zod";

const sqsClient = new SQSClient({
  endpoint: "http://localhost:9324",
  region: "elasticmq",
  credentials: {
    accessKeyId: "x",
    secretAccessKey: "x",
  },
});

const queueUrl = "http://localhost:9324/000000000000/equipment.fifo";

export async function changeEquipmentState(formData: FormData) {
  const orderSchema = z.object({
    equipment: z.string().min(1, { message: "Equipment is required" }),
    state: z.enum(["0", "1", "2"], {
      errorMap: () => ({ message: "State is required" }),
    }),
  });

  const validatedFields = orderSchema.safeParse({
    equipment: formData.get("equipment"),
    state: formData.get("state"),
  });

  if (!validatedFields.success) {
    return { error: validatedFields.error.flatten().fieldErrors };
  }

  const message = new SendMessageCommand({
    QueueUrl: queueUrl,
    MessageBody: JSON.stringify(validatedFields.data),
    MessageGroupId: "group1",
  });

  const response = await sqsClient.send(message);

  console.log("Message sent to SQS:", response);

  redirect("/");
}
