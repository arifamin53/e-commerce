
import React, { useState } from 'react'
import Navbar from './components/Navbar/Navbar'
import { Route, Routes, useLocation } from 'react-router-dom'
import Cart from './pages/cart/Cart'
import PlaceOrder from './pages/placeOrder/PlaceOrder'
import Home from './pages/home/Home'
import Footer from './components/footer/Footer'
import LoginPOPup from './components/loginPopup/LoginPOPup.Jsx'
import AdminLayout from './admin/admin-components/admin-layout'
import Dashboard from './admin/AdminPages/Dashboard'
import AddCategory from './admin/AdminPages/category/add-category'
import AllCategories from './admin/AdminPages/category/get-categories'
import EditCategory from './admin/AdminPages/category/Edit-Category'


const App = () => {
  const [showLogin, setShowLogin] = useState(false)
  const location = useLocation();
  const isAdminRoute = location.pathname.startsWith("/admin")
  return (
   

      <div className='app'>
        {
          showLogin ? <LoginPOPup setShowLogin={setShowLogin} /> : <></>
        }
        {
          !isAdminRoute &&<Navbar setShowLogin={setShowLogin} />
        }
        
        <Routes>
          <Route path='/' element={<Home />} />
          <Route path='/food-app/cart' element={<Cart setShowLogin={setShowLogin} />} />
          <Route path='/food-app/place-order' element={<PlaceOrder />} />
        
     
      
       
          <Route path='/admin' element={<AdminLayout />} />
          <Route path="/admin/dashboard" element={<Dashboard />} />
          <Route path="/admin/add-category" element={<AddCategory />} />
          <Route path="/admin/all-categories" element={<AllCategories />} />
          <Route path="/admin/edit-category/:id" element={<EditCategory />} />
        </Routes>
      </div>
   
  )
}

export default App
