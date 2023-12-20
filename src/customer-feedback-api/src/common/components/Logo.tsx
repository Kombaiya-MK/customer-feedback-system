import React from "react";

const Logo: React.FC = () => {
  return (
    <div className="flex items-center">
      <div className="w-10 h-10 bg-blue-500 mr-2 rounded-full"></div>
      <div className="text-lg font-bold text-gray-800">Your Logo</div>
    </div>
  );
};

export default Logo;
