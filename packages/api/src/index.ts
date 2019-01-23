import { AzureFunction } from "@azure/functions";

interface IApiRequestBody {
  command: string;
}

export const handler: AzureFunction = async (context, args) => {
  if (!context.req) {
    return new Error("expected request object");
  }

  const body = context.req.body as IApiRequestBody;

  if (!body.command) {
    throw new Error("expected command");
  }

  const headers = { "Content-Type": "application/json" };

  return { body, headers };
};
