import axios from "axios";

const authUser = (password, email) => {
  axios
    .post("http://localhost:5001/api/users/login", {
      email: email,
      pass: password,
    })
    .then(function (response) {
      console.log("сработало");
      localStorage.setItem("cometFoodLogin", response.data.token);
      localStorage.setItem("cometFoodUserName", response.data.name);
    })
    .catch(function (error) {
      console.log(error.message);
    });
};

const getRestorants = (setItems, setIsLoading) => {
  axios
    .get(`http://localhost:5001/api/shops/`)
    .then(function (response) {
      setItems(response.data);
      setIsLoading(false);
    })
    .catch(function (error) {
      console.log(error.message);
    });
};

export { authUser, getRestorants };
