module.exports = async (context, req) => {
  const { id } = req.params;
  const team = { id };
  const body = { team };

  return {
    body: JSON.stringify(body),
    headers: {
      "Content-Type": "application/json"
    }
  };
};
