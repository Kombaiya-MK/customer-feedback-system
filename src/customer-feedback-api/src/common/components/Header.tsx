import React from "react";
import Logo from "./Logo";

const Header: React.FC = () => {
  return (
    <header className="bg-gray-800 p-4 text-white flex justify-between items-center">
      <Logo />
      <nav className="flex space-x-4">
        <a href="#" className="text-gray-300 hover:text-white">
          Home
        </a>
        <a href="#" className="text-gray-300 hover:text-white">
          Products
        </a>
        <a href="#" className="text-gray-300 hover:text-white">
          About
        </a>
        <a href="#" className="text-gray-300 hover:text-white">
          Contact
        </a>
      </nav>
    </header>
  );
};

export default Header;
