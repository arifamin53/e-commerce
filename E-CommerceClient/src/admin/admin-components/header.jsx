import { Bell } from "lucide-react";
import React, { useContext, useEffect, useState } from "react";
import { StoreContext } from "../../context/StoreContext";
import { useNavigate, useSearchParams } from "react-router-dom";
import { getCount, getOrderByStatus } from "../../service/orderService/orderService";

const Header = () => {
  const navigate = useNavigate();
  const {getTotalCartAmount}=useContext(StoreContext)
  const [orders,setOrders]=useState()

  const fetchingOrdersBySrtatus = async () =>{
    const response = await getCount();
    if(response.isSuccess){
      setOrders(response.value)
    }
  }

  useEffect(()=>{
  fetchingOrdersBySrtatus();
  },[])

  
  return (
    <div className="admin-header">
      <h1>Admin Dashboard</h1>
      <div className="admin-user">
        <img
          src="https://via.placeholder.com/40"
          alt="Admin"
          className="admin-avatar"
        />
        <span>Admin</span>
      </div>
     <div className="relative cursor-pointer">
        <Bell size={24} onClick={()=>navigate("/admin/orders")}/>

        {/* Notification Badge */}
        <span className="absolute -top-5 -right-2 bg-red-500 text-white text-xs w-5 h-5 flex items-center justify-center rounded-full">
          {orders}
        </span>
      </div>
    </div>
  );
};

export default Header;