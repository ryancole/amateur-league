import { AzureFunction, HttpRequest } from "@azure/functions";

export const run: AzureFunction = async (context, req: HttpRequest) => {
  return { body: "poo poo" };
};
