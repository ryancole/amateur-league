import AWS from "aws-sdk";

AWS.config.update({ region: "us-east-2" });

export async function fetchAll() {
  const client = new AWS.DynamoDB.DocumentClient();
  const query = await client.query({ TableName: "teams" }).promise();
  console.log(query.Items);
}
