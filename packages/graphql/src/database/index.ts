import { CosmosClient, QueryCompatibilityMode } from "@azure/cosmos";

const endpoint = process.env["CosmosEndpoint"] || "";

export default new CosmosClient({
  endpoint,
  auth: { masterKey: process.env["CosmosKey"] },
  connectionPolicy: {
    DisableSSLVerification: true
  }
});
