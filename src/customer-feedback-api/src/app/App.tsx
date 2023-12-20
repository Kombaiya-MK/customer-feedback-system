import { BrowserRouter, Routes, Route } from "react-router-dom";
import Home from "../common/components/Home";
import FeedbackPage from "../common/components/FeedbackPage";

const productId = 1;
function App() {
  return (
    <div className="App">
      <BrowserRouter>
        <Routes>
          <Route path="/" element={<Home />} />
          <Route
            path="feedbacks/products/:id"
            element={<FeedbackPage productId={productId} />}
          />
        </Routes>
      </BrowserRouter>
    </div>
  );
}

export default App;
