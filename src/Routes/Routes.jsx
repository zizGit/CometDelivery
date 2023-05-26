import React, { useEffect } from "react";
import { Routes, Route, Navigate } from "react-router-dom";
import RestorantPage from "../Pages/RestorantPage";
import OrderPage from "../Pages/OrderPage/OrderPage";

import Admin from "../Pages/Admin";
import EstablishmentBlock from "../Pages/EstablishmentBlock";

import { useSelector } from "react-redux";
import MainPage from "../Pages/MainPage";
import PartnerPage from "../Pages/PartnerPage";

export default function AppRoutes() {
  const { isLogin } = useSelector((state) => state.loginSlice);
  const { cart } = useSelector((state) => state.cart);
  useEffect(() => {}, [cart, isLogin]);

  return (
    <Routes>
      {isLogin ? (
        <>
          <Route path="/establishment" element={<EstablishmentBlock />} />
          <Route path="/establishment/:title" element={<RestorantPage />} />
          {cart.length > 0 ? (
            <Route path="/order" element={<OrderPage />} />
          ) : (
            <Route
              path="*"
              element={<Navigate to="/establishment" replace />}
            />
          )}

          <Route path="/admin" element={<Admin />} />
        </>
      ) : (
        <>
          <Route path="/partner" element={<PartnerPage />} />

          <Route path="/establishment" element={<Navigate to="/" replace />} />
          <Route path="/*" element={<Navigate to="/" replace />} />
        </>
      )}
      <Route path="/partner" element={<PartnerPage />} />
      <Route path="/" element={<MainPage />} />
    </Routes>
  );
}
