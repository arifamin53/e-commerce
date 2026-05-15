import React from "react";
import { Package, ShoppingCart, Users, IndianRupee } from "lucide-react";

const Dashboard = () => {
  const stats = [
    {
      title: "Total Products",
      value: 120,
      icon: <Package size={28} />,
      color: "from-blue-500 to-indigo-600",
    },
    {
      title: "Total Orders",
      value: 45,
      icon: <ShoppingCart size={28} />,
      color: "from-purple-500 to-pink-500",
    },
    {
      title: "Total Users",
      value: 80,
      icon: <Users size={28} />,
      color: "from-green-500 to-emerald-600",
    },
    {
      title: "Revenue",
      value: "₹50,000",
      icon: <IndianRupee size={28} />,
      color: "from-orange-500 to-red-500",
    },
  ];

  return (
    <div className="p-6 md:p-10 bg-gray-50 min-h-screen">
      
      {/* 🔥 Header */}
      <div className="mb-8">
        <h1 className="text-2xl md:text-3xl font-bold text-gray-800">
          Admin Dashboard
        </h1>
        <p className="text-gray-500 text-sm mt-1">
          Overview of your store performance
        </p>
      </div>

      {/* 🔥 Cards */}
      <div className="grid grid-cols-1 sm:grid-cols-2 lg:grid-cols-4 gap-6">
        {stats.map((item, index) => (
          <div
            key={index}
            className={`relative p-6 rounded-2xl text-white shadow-lg 
            bg-gradient-to-r ${item.color} 
            transform hover:scale-105 transition duration-300`}
          >
            {/* Icon */}
            <div className="absolute top-4 right-4 opacity-20">
              {item.icon}
            </div>

            {/* Content */}
            <h3 className="text-sm font-medium opacity-90">
              {item.title}
            </h3>
            <p className="text-2xl font-bold mt-2">
              {item.value}
            </p>
          </div>
        ))}
      </div>
    </div>
  );
};

export default Dashboard;