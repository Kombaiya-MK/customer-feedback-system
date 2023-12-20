import axios from "axios";
import * as actions from "../api";

const ApiKey = "test-api-authentication-key";
const api =
  ({ dispatch, getState }) =>
  (next) =>
  async (action) => {
    if (action.type !== actions.apiCallBegan.type) return next(action);
    const { url, data, method, onSuccess, onError } = action.payload;
    next(action);
    console.log(url);
    try {
      const response = await axios.request({
        baseURL: "https://localhost:7012/api",
        url,
        method,
        data,
        headers: {
          ApiKey: `${ApiKey}`,
        },
      });
      console.log(data);
      console.log(response.data);
      dispatch({
        type: onSuccess,
        payload: response.data,
      });
    } catch (error) {
      console.log(error.message);
      dispatch({
        type: onError,
        payload: error.message,
      });
    }
  };

export default api;
