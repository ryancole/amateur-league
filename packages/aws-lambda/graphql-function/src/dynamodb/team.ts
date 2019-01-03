import AWS from "aws-sdk";

AWS.config.update({ region: "us-east-2" });

export async function fetchAll() {
  try {
    const client = new AWS.DynamoDB.DocumentClient({
      endpoint: "http://localhost:9000"
    });
    const query = await client.query({ TableName: "Teams" }).promise();
    console.log(query.Items);
  } catch (e) {
    console.log({ e });
  }
}
