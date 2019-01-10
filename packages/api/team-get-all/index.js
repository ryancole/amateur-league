module.exports = async (context, req) => {
  const teams = [];
  const body = { teams };

  return {
    body: JSON.stringify(body),
    headers: {
      "Content-Type": "application/json"
    }
  };
};
