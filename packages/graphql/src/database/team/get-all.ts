import client from "../index";

export default async function getAll() {
  const teams = client
    .database("league")
    .container("teams")
    .items.readAll()
    .toArray();

  return teams;
}
