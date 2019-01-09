export default function JsonResponse(response, body) {
  // convert our body to json
  const data = JSON.stringify(body);

  // specify some json headers
  response.writeHead(200, { "Content-Type": "application/json" });

  // transmit the data
  return response.end(data, "utf8");
}
