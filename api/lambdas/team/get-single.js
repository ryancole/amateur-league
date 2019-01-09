import JsonResponse from "../../common/json-response";

export default function(req, res) {
  const team = {};
  const response = { team };
  return JsonResponse(res, response);
}
