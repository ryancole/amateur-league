import path from "path";

export const handlers = {
  "team-get-all": path.resolve(__dirname, "team/get-all"),
  "team-get-single": path.resolve(__dirname, "team/get-single")
};
