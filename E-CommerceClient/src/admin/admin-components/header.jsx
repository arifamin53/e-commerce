import { Bell } from "lucide-react";
import React, { useContext, useEffect, useState } from "react";
import { StoreContext } from "../../context/StoreContext";
import { useNavigate } from "react-router-dom";
import { getCount } from "../../service/orderService/orderService";

const Header = () => {
  const navigate = useNavigate();
  const { getTotalCartAmount } = useContext(StoreContext);
  const [orders, setOrders] = useState(0);

  const fetchingOrdersByStatus = async () => {
    try {
      const response = await getCount();
      if (response.isSuccess) {
        setOrders(response.value);
      }
    } catch (err) {
      console.error(err);
    }
  };

  useEffect(() => {
    fetchingOrdersByStatus();
  }, []);

  return (
    <div className="h-full bg-white shadow flex items-center justify-between px-6">
      
      {/* Title */}
      <h1 className="text-lg font-semibold text-gray-700">
        Admin Dashboard
      </h1>

      {/* Right Section */}
      <div className="flex items-center gap-6">
        
        {/* Notification */}
        <div
          className="relative cursor-pointer"
          onClick={() => navigate("/admin/orders")}
        >
          <Bell className="text-gray-600 hover:text-black" size={22} />

          <span className="absolute -top-2 -right-2 bg-red-500 text-white text-xs w-5 h-5 flex items-center justify-center rounded-full">
            {orders}
          </span>
        </div>

        {/* User */}
        <div className="flex items-center gap-2">
          <img
            src="https://via.placeholder.com/40"
            alt="Admin"
            className="w-9 h-9 rounded-full"
          />
          <span className="text-sm text-gray-700 font-medium">
            Admin
          </span>
        </div>

      </div>
    </div>
  );
};

export default Header;