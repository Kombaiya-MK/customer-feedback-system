import React from "react";

interface UserTypeProps {
  userType: string;
}

const UserType: React.FC<UserTypeProps> = ({ userType }) => {
  return (
    <div className="text-gray-600 text-sm mt-2">User Type: {userType}</div>
  );
};

export default UserType;
