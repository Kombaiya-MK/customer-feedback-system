import React, { useState, useEffect } from "react";
import { useSelector, useDispatch } from "react-redux";
import { RootState } from "../../store/configureStore";
import FeedbackComponent from "./FeedbackComponent";
import StarRating from "../utils/StarRating";
import { addFeedback, retriveFeedbacks } from "../../store/feedbackSlice";

interface FeedbackPageProps {
  productId: number;
}

const FeedbackPage: React.FC<FeedbackPageProps> = ({ productId }) => {
  const dispatch = useDispatch();

  useEffect(() => {
    dispatch(retriveFeedbacks(productId));
  }, [dispatch, productId]);

  const feedbacks = useSelector(
    (state: RootState) => state.entities.feedbacks.list
  );

  const [newFeedback, setNewFeedback] = useState({
    userId: Math.floor(Math.random() * 1000),
    productId: productId,
    rating: 0,
    comment: "",
  });

  const handleRatingChange = (newRating: number) => {
    setNewFeedback((prevFeedback) => ({
      ...prevFeedback,
      rating: newRating,
    }));
  };

  const handleCommentChange = (
    event: React.ChangeEvent<HTMLTextAreaElement>
  ) => {
    setNewFeedback((prevFeedback) => ({
      ...prevFeedback,
      comment: event.target.value,
    }));
  };

  const handleSubmit = () => {
    dispatch(addFeedback(newFeedback));
    dispatch(retriveFeedbacks(productId));
  };

  return (
    <div className="max-w-screen-xl mx-auto p-6">
      <h2 className="text-3xl font-semibold mb-4">Product Feedback</h2>
      <div className="grid grid-cols-1 md:grid-cols-2 lg:grid-cols-3 gap-8">
        {feedbacks.map((feedback) => (
          <FeedbackComponent key={feedback} feedback={feedback} />
        ))}
      </div>
      <div className="mt-8">
        <h3 className="text-lg font-semibold mb-2">Add Your Feedback</h3>
        <StarRating rating={newFeedback.rating} onChange={handleRatingChange} />
        <textarea
          className="border p-2 w-full mt-2"
          placeholder="Enter your feedback..."
          value={newFeedback.comment}
          onChange={handleCommentChange}
        />
        <button
          onClick={handleSubmit}
          className="bg-blue-500 text-white p-2 mt-2"
        >
          Submit Feedback
        </button>
      </div>
    </div>
  );
};

export default FeedbackPage;
