import { ClientRequest, ServerResponse } from "http";
import JsonResponse from "../../common/json-response";

export interface Team {}

export default function(req: ClientRequest, res: ServerResponse) {
  const teams: Array<Team> = [];
  const response = { teams };
  return JsonResponse(res, response);
}
