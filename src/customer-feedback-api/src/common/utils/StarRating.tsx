import React from "react";

interface StarRatingProps {
  rating: number;
  onChange?: (newRating: number) => void; // Optional onChange callback for interactive rating
}

const StarRating: React.FC<StarRatingProps> = ({ rating, onChange }) => {
  const stars = Array.from({ length: 5 }, (_, index) => index + 1);

  const handleStarClick = (newRating: number) => {
    if (onChange) {
      onChange(newRating);
    }
  };

  return (
    <div className="flex">
      {stars.map((star) => (
        <span
          key={star}
          onClick={() => handleStarClick(star)}
          className={`cursor-pointer ${
            star <= rating ? "text-yellow-500" : "text-gray-300"
          } text-2xl mr-1`}
        >
          ★
        </span>
      ))}
    </div>
  );
};

export default StarRating;
