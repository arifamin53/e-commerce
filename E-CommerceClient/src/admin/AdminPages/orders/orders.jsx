import React, { useEffect, useState } from "react";
import {
  getOrderByStatus,
  updateOrderStatus,
} from "../../../service/orderService/orderService";

const AdminOrders = () => {
  const [orders, setOrders] = useState([]);
  const [filter, setFilter] = useState("All");
  const [loading, setLoading] = useState(false);

  const OrderStatus = {
    1: "Pending",
    2: "Confirmed",
    3: "Canceled",
    4: "Shipped",
    5: "Paid",
  };

  const StatusToNumber = Object.fromEntries(
    Object.entries(OrderStatus).map(([k, v]) => [v, Number(k)])
  );

  const fetchOrders = async () => {
    try {
      setLoading(true);
      const response = await getOrderByStatus();
      if (response.isSuccess) setOrders(response.value);
    } catch (err) {
      console.error(err);
    } finally {
      setLoading(false);
    }
  };

  useEffect(() => {
    fetchOrders();
  }, []);

  const filteredOrders =
    filter === "All"
      ? orders
      : orders.filter((o) => OrderStatus[o.status] === filter);

  const handleStatusChange = async (id, newStatus) => {
    try {
      const statusNumber = StatusToNumber[newStatus];

      const response = await updateOrderStatus({
        id,
        orderStatus: statusNumber,
      });

      if (response.isSuccess) {
        setOrders((prev) =>
          prev.map((o) =>
            o.id === id ? { ...o, status: statusNumber } : o
          )
        );
      }
    } catch (err) {
      console.error(err);
    }
  };

  const getStatusStyle = (status) => {
    switch (status) {
      case "Pending":
        return "bg-yellow-100 text-yellow-700";
      case "Confirmed":
        return "bg-blue-100 text-blue-700";
      case "Shipped":
        return "bg-purple-100 text-purple-700";
      case "Canceled":
        return "bg-red-100 text-red-700";
      case "Paid":
        return "bg-green-100 text-green-700";
      default:
        return "bg-gray-100 text-gray-600";
    }
  };

  return (
    <div className="p-6 md:p-10 bg-gray-50 min-h-screen">
      {/* 🔥 Header */}
      <div className="mb-6">
        <h1 className="text-2xl font-bold text-gray-800">Orders Management</h1>
        <p className="text-sm text-gray-500">
          Manage and track all customer orders
        </p>
      </div>

      {/* 🔥 Filter Buttons */}
      <div className="flex flex-wrap gap-3 mb-6">
        {["All", "Pending", "Confirmed", "Shipped", "Canceled", "Paid"].map(
          (status) => (
            <button
              key={status}
              onClick={() => setFilter(status)}
              className={`px-5 py-2 rounded-full text-sm font-medium transition-all duration-300
              ${
                filter === status
                  ? "bg-blue-600 text-white shadow-lg scale-105"
                  : "bg-white border border-gray-200 text-gray-700 hover:bg-gray-100"
              }`}
            >
              {status}
            </button>
          )
        )}
      </div>

      {/* 🔥 Table */}
      <div className="overflow-x-auto bg-white rounded-2xl shadow-lg border">
        <table className="min-w-full text-sm text-left">
          {/* Header */}
          <thead className="bg-gray-100 text-gray-600 uppercase text-xs sticky top-0">
            <tr>
              <th className="px-5 py-3">Customer</th>
              <th className="px-5 py-3">Contact</th>
              <th className="px-5 py-3">Location</th>
              <th className="px-5 py-3">Amount</th>
              <th className="px-5 py-3">Date</th>
              <th className="px-5 py-3">Status</th>
              <th className="px-5 py-3 text-center">Action</th>
            </tr>
          </thead>

          {/* Body */}
          <tbody className="divide-y">
            {loading ? (
              <tr>
                <td colSpan="7" className="text-center py-8 text-gray-500">
                  Loading orders...
                </td>
              </tr>
            ) : filteredOrders.length === 0 ? (
              <tr>
                <td colSpan="7" className="text-center py-8 text-gray-400">
                  No orders found
                </td>
              </tr>
            ) : (
              filteredOrders.map((order, index) => {
                const status = OrderStatus[order.status];

                return (
                  <tr
                    key={order.id}
                    className={`transition ${
                      index % 2 === 0 ? "bg-white" : "bg-gray-50"
                    } hover:bg-blue-50`}
                  >
                    {/* Customer */}
                    <td className="px-5 py-4">
                      <div className="font-medium text-gray-800">
                        {order.name}
                      </div>
                      <div className="text-xs text-gray-500">
                        {order.email}
                      </div>
                    </td>

                    {/* Contact */}
                    <td className="px-5 py-4 text-gray-600">
                      {order.contactNo}
                    </td>

                    {/* Location */}
                    <td className="px-5 py-4 text-gray-600 text-xs">
                      {order.city}, {order.state}
                      <br />
                      {order.country}
                    </td>

                    {/* Amount */}
                    <td className="px-5 py-4 font-semibold text-gray-800">
                      ₹{order.totalAmount}
                    </td>

                    {/* Date */}
                    <td className="px-5 py-4 text-gray-500 text-xs">
                      {order.orderDate}
                    </td>

                    {/* Status */}
                    <td className="px-5 py-4">
                      <span
                        className={`px-3 py-1 rounded-full text-xs font-medium ${getStatusStyle(
                          status
                        )}`}
                      >
                        {status}
                      </span>
                    </td>

                    {/* Action */}
                    <td className="px-5 py-4 text-center">
                      {status === "Pending" && (
                        <button
                          onClick={() =>
                            handleStatusChange(order.id, "Confirmed")
                          }
                          className="px-3 py-1 text-xs bg-yellow-500 text-white rounded-lg hover:bg-yellow-600"
                        >
                          Confirm
                        </button>
                      )}

                      {status === "Confirmed" && (
                        <button
                          onClick={() =>
                            handleStatusChange(order.id, "Shipped")
                          }
                          className="px-3 py-1 text-xs bg-blue-500 text-white rounded-lg hover:bg-blue-600"
                        >
                          Ship
                        </button>
                      )}

                      {status === "Shipped" && (
                        <span className="text-xs text-green-600 font-medium">
                          Completed
                        </span>
                      )}

                      {status === "Canceled" && (
                        <span className="text-xs text-red-500 font-medium">
                          Canceled
                        </span>
                      )}

                      {status === "Paid" && (
                        <span className="text-xs text-green-700 font-medium">
                          Paid
                        </span>
                      )}
                    </td>
                  </tr>
                );
              })
            )}
          </tbody>
        </table>
      </div>
    </div>
  );
};

export default AdminOrders;