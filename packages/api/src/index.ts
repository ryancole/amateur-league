import { Handler } from "aws-lambda";

export const handler: Handler = async (event, context) => {
  const body = JSON.parse(event.body);

  return {
    body: JSON.stringify(event),
    headers: { "Content-Type": "application/json" }
  };
};
