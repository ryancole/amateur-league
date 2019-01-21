import path from "path";

export interface CommandModulePaths {
  [index: string]: string;
}

const commandModulePaths: CommandModulePaths = {
  "team-get-all": path.resolve(__dirname, "team/get-all"),
  "team-get-single": path.resolve(__dirname, "team/get-single")
};

export default commandModulePaths;
