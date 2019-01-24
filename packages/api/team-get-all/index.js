module.exports = async (context, req) => {
  const teams = [];
  return { body: { teams }, headers: { "Content-Type": "application/json" } };
};
