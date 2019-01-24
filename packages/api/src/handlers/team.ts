import { Handler } from "aws-lambda";
import headers from "../common/responseHeaders";

export const getAll: Handler = async (event, context) => {
  const body = {
    teams: []
  };

  return { body: JSON.stringify(body), headers };
};

export const getSingle: Handler = async (event, context) => {
  const body = {
    team: {}
  };

  return { body: JSON.stringify(body), headers };
};
