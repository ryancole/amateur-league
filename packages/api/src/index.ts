import { Handler } from "aws-lambda";
import commands from "./commands";

export const handler: Handler = async (event, context) => {
  const body = JSON.parse(event.body);

  // the user specifies which command they'd like to query
  const { command } = body;

  // we can now get the handler for thr requested command
  const commandHandler = commands[command];

  return {
    body: JSON.stringify(event),
    headers: { "Content-Type": "application/json" }
  };
};
