import React from "react";
import StarRating from "../utils/StarRating";

interface ProductProps {
  name: string;
  price: number;
  description: string;
  averageRating: number;
}

const Product: React.FC<ProductProps> = ({
  name,
  price,
  description,
  averageRating,
}) => {
  return (
    <div className="border p-4 mb-4">
      <h3 className="text-lg font-semibold">{name}</h3>
      <p className="text-gray-600">${price}</p>
      <p className="text-gray-700">{description}</p>
      <StarRating rating={averageRating} />{" "}
    </div>
  );
};

export default Product;
