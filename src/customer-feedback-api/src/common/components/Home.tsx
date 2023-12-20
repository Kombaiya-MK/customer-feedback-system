import React, { useEffect } from "react";
import { useSelector, useDispatch } from "react-redux";
import { RootState } from "../../store/configureStore";
import { addFeedback, retriveFeedbacks } from "../../store/feedbackSlice";
import Header from "./Header";
import Product from "./Product";
import FeedbackComponent from "./Feedback";
import UserType from "../utils/UserType";
import Loader from "../utils/Loader";
import Modal from "../utils/Modal";
import { useNavigate } from "react-router-dom";

interface Feedback {
  userId: number;
  productId: number;
  rating: number;
  comment: string;
}

interface ProductData {
  id: number;
  name: string;
  price: number;
  description: string;
  averageRating: number;
}

const Home: React.FC = () => {
  const dispatch = useDispatch();
  const navigate = useNavigate();

  useEffect(() => {
    dispatch(retriveFeedbacks());
  }, [dispatch]);

  const feedbacks: Feedback[] = useSelector(
    (state: RootState) => state.entities.feedbacks.list
  );

  const products: ProductData[] = [
    {
      id: 1,
      name: "Laptop",
      price: 1200,
      description: "Powerful laptop for work and play",
      averageRating: 4.8,
    },
    {
      id: 2,
      name: "Smartphone",
      price: 800,
      description: "Latest smartphone with great camera",
      averageRating: 4.5,
    },
    {
      id: 3,
      name: "Headphones",
      price: 150,
      description: "Wireless headphones for immersive sound",
      averageRating: 4.2,
    },
    {
      id: 4,
      name: "Tablet",
      price: 300,
      description: "Portable tablet for entertainment",
      averageRating: 4.0,
    },
    {
      id: 5,
      name: "Gaming Console",
      price: 500,
      description: "High-performance gaming console",
      averageRating: 4.7,
    },
    {
      id: 6,
      name: "Fitness Tracker",
      price: 80,
      description: "Track your fitness and health",
      averageRating: 4.3,
    },
    {
      id: 7,
      name: "Bluetooth Speaker",
      price: 50,
      description: "Compact speaker for on-the-go music",
      averageRating: 4.5,
    },
    {
      id: 8,
      name: "Coffee Maker",
      price: 100,
      description: "Automatic coffee maker for your mornings",
      averageRating: 4.6,
    },
    {
      id: 9,
      name: "External Hard Drive",
      price: 120,
      description: "Expand your storage with a reliable hard drive",
      averageRating: 4.9,
    },
    {
      id: 10,
      name: "Wireless Mouse",
      price: 25,
      description: "Comfortable and responsive wireless mouse",
      averageRating: 4.2,
    },
  ];

  const handleFeedbackButtonClick = (productId: number) => {
    navigate(`/feedbacks/product/${productId}`);
  };

  return (
    <div className="max-w-screen-xxl mx-auto p-6">
      <Header />
      <h2 className="text-3xl font-semibold mb-4">Featured Products</h2>
      <div className="grid grid-cols-1 md:grid-cols-2 lg:grid-cols-3 gap-8">
        {products.map((product) => (
          <div key={product.id} className="bg-white p-6 rounded-lg shadow-md">
            <Product {...product} />
            <button
              onClick={() => handleFeedbackButtonClick(product.id)}
              className="bg-blue-500 text-white p-2 mt-4 w-full"
            >
              View Feedback
            </button>
          </div>
        ))}
      </div>
      <div className="mt-8">
        {feedbacks.map((feedback) => (
          <FeedbackComponent key={feedback.productId} feedback={feedback} />
        ))}
      </div>
    </div>
  );
};

export default Home;
