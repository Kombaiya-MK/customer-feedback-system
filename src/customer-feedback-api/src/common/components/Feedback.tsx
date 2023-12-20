import React from "react";

interface Feedback {
  userId: number;
  productId: number;
  rating: number;
  comment: string;
}

interface FeedbackProps {
  feedback: Feedback;
}

const FeedbackComponent: React.FC<FeedbackProps> = ({ feedback }) => {
  return (
    <div className="border p-4 mb-4">
      <p>{feedback.comment}</p>
      <p>Rating: {feedback.rating}</p>
    </div>
  );
};

export default FeedbackComponent;
