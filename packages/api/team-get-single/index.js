module.exports = async (context, req) => {
  const { id } = context.bindingData;
  const team = { id };
  return { body: { team }, headers: { "Content-Type": "application/json" } };
};
