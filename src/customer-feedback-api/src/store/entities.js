import { combineReducers } from "@reduxjs/toolkit";
import feedbackReducer from "./feedbackSlice";

export default combineReducers({
  feedbacks: feedbackReducer,
});
