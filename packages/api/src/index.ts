import { Handler } from "aws-lambda";
import commands from "./commands";

export const handler: Handler = async (event, context) => {
  const body = JSON.parse(event.body);

  // the user specifies which command they'd like to query
  const command: string = body.command;

  // given the command name, we can determine the code path to load
  const commandModulePath = commands[command];

  // load up the command module
  const commandModule = require(commandModulePath).default;

  console.log(commandModule);

  return {
    body: "woot",
    headers: { "Content-Type": "application/json" }
  };
};
