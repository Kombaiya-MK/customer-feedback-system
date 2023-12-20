import { createSlice } from "@reduxjs/toolkit";
import { apiCallBegan } from "./api";

const slice = createSlice({
  name: "feedbacks",
  initialState: {
    list: [],
    errors: [],
  },
  error: "",
  reducers: {
    feedbackAdded: (feedbacks, action) => {
      feedbacks.list.push(action.payload);
    },
    feedbackRetrived: (feedbacks, action) => {
      feedbacks.list = action.payload;
    },
    feedbackFailed: (feedbacks, action) => {
      feedbacks.errors = action.payload;
    },
  },
});

const { feedbackAdded, feedbackRetrived } = slice.actions;
export default slice.reducer;

export const addFeedback = (feedback) =>
  apiCallBegan({
    url: "feedbacks",
    method: "POST",
    data: feedback,
    onSuccess: feedbackAdded.type,
    onError: feedbackAdded.type,
  });

export const retriveFeedbacks = (id) =>
  apiCallBegan({
    url: `feedbacks/product/${id}`,
    onSuccess: feedbackRetrived.type,
  });
