import JsonResponse from "../../common/json-response";

export default function(req, res) {
  const teams = [];
  const response = { teams };
  return JsonResponse(res, response);
}
