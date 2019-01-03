import AWS from "aws-sdk";

const documents = new AWS.DynamoDB.DocumentClient({ region: "us-east-2" });

export async function fetchAll() {
  const response = await documents.scan({ TableName: "Teams" }).promise();
  return response.Items;
}
