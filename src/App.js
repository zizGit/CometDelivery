import "./App.css";
import Header from "./components/Header";
import Footer from "./components/Footer";
import PartnerPage from "./Pages/PartnerPage";
import MainPage from "./Pages/MainPage";
import Establishment from "./Pages/Establishment";
import RestorantPage from "./Pages/RestorantPage";
import OrderPage from "./Pages/OrderPage/OrderPage";
import { Routes, Route } from "react-router-dom";

import axios from "axios";

function App() {
  axios
    .get("https://fortnite-api.com/v1/map")
    .then((response) => console.log(response.status))
    .catch((error) => {
      console.error(error);
    });
  return (
    <div>
      <Header />
      <Routes>
        <Route path="/" element={<MainPage />} />
        <Route path="/partner" element={<PartnerPage />} />
        <Route path="/establishment" element={<Establishment />} />
        <Route path="/establishment/$id" element={<RestorantPage />} />
        <Route path="/order" element={<OrderPage />} />
      </Routes>
      <Footer />
    </div>
  );
}

export default App;
