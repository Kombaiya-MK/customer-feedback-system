import React, { useState } from "react";
import StarRating from "../utils/StarRating";
import { useDispatch } from "react-redux";
import { addFeedback, retriveFeedbacks } from "../../store/feedbackSlice";

interface Feedback {
  userId: number;
  productId: number;
  rating: number;
  comment: string;
}

interface FeedbackProps {
  feedbacks: Feedback[];
  feedbackType: React.FC<Feedback>;
}

const FeedbackComponent: React.FC<FeedbackProps> = ({ feedbacks }) => {
  const dispatch = useDispatch();
  const [newFeedback, setNewFeedback] = useState<Feedback>({
    userId: 1, // Assume a default user ID for simplicity
    productId: 1, // Assume a default product ID for simplicity
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
    // After submitting, retrieve the updated feedbacks
    dispatch(retriveFeedbacks());
  };

  const averageRating = calculateAverageRating(
    feedbacks,
    newFeedback.productId
  );

  return (
    <div>
      <h2 className="text-2xl font-semibold mb-4">Feedback Component</h2>
      <div>
        {feedbacks.map((feedback) => (
          <div key={feedback.productId} className="border p-4 mb-4">
            <p>{feedback.comment}</p>
            <StarRating rating={feedback.rating} />
          </div>
        ))}
      </div>
      <div className="mt-4">
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
      <div className="mt-4">
        <h3 className="text-lg font-semibold mb-2">Average Rating</h3>
        <StarRating rating={averageRating} />
      </div>
    </div>
  );
};

// Helper function to calculate the average rating for a specific product
const calculateAverageRating = (feedbacks: Feedback[], productId: number) => {
  const productFeedbacks = feedbacks.filter(
    (feedback) => feedback.productId === productId
  );
  const totalRating = productFeedbacks.reduce(
    (sum, feedback) => sum + feedback.rating,
    0
  );
  return productFeedbacks.length > 0
    ? Math.round(totalRating / productFeedbacks.length)
    : 0;
};

export default FeedbackComponent;
