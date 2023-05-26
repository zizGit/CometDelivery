import axios from "axios";

const loginUser = (userData, setVisiblePopUp, setUserAuth, setError) => {
  axios
    .post(`http://localhost:5001/api/users/login`, userData)
    .then(function (response) {
      console.log("login :>> ", response.data);
      if (response.data.status === 200) {
        setVisiblePopUp(false);
        setUserAuth(true);
        localStorage.setItem("cometFoodLogin", response.data.token);
        localStorage.setItem("cometFoodUserId", response.data.id);
      }
    })
    .catch(function (error) {
      setError("Wrong login or password");
    });
};
const registerUser = (userData, setVisiblePopUp, setUserAuth, setError) => {
  axios
    .post(`http://localhost:5001/api/users/registration`, userData)
    .then(function (response) {
      console.log("response :>> ", response);
      console.log("response.data :>> ", response.data);
      if (response.status === 201) {
        setVisiblePopUp(false);
        setUserAuth(true);
        userData = { email: response.data.email, pass: response.data.pass };
        console.log("userData2 :>> ", userData);
        loginUser(userData, setVisiblePopUp, setUserAuth);
      } else if (response.data.status === 400) {
        console.log("response.data.errors :>> ", response.data.errors);
        setError(
          response.data.errors.email ||
            response.data.errors.pass ||
            response.data.errors.phone
        );
      }
    })
    .catch(function (error) {
      setError("This email already exist");
    });
};

const authUser = ({
  path,
  password,
  email,
  name,
  phoneNumber,
  setVisiblePopUp,
  setUserAuth,
  setError,
}) => {
  let userData = {};
  if (path === "login") {
    userData = {
      email: email,
      pass: password,
    };
    loginUser(userData, setVisiblePopUp, setUserAuth, setError);
  } else {
    userData = {
      name: name,
      email: email,
      pass: password,
      phone: +phoneNumber,
    };
    console.log("userData :>> ", userData);
    registerUser(userData, setVisiblePopUp, setUserAuth, setError);
  }
};

const tokenValidation = (setUserAuth) => {
  let token = localStorage.getItem("cometFoodLogin");
  axios
    .post("http://localhost:5001/api/users/login", {
      token,
    })
    .then(function (response) {
      if (response.data.status === 200 || response.data === 200) {
        setUserAuth();
      }
    })
    .catch(function (error) {
      // console.log(error.message);
    });
};

const getRestorants = (setItems, setIsLoading, category) => {
  axios
    .get(`http://localhost:5001/api/shops/type/${category}`)
    .then(function (response) {
      setItems(response.data);
      setIsLoading(false);
    })
    .catch(function (error) {
      console.log(error.message);
    });
};
const getRestorantsByName = (name, setItems, setIsLoading) => {
  axios
    .get(`http://localhost:5001/api/shops/search/${name}`)
    .then(function (response) {
      console.log("response :>> ", response);
      setItems([...response.data]);
      setIsLoading(false);
    })
    .catch(function (error) {
      setIsLoading(true);
    });
};

const getProducts = (restorant, activeCategory, setItems, setIsLoading) => {
  axios
    .get(
      `http://localhost:5001/api/products/${restorant.name}/${activeCategory.name}`
    )
    .then(function (response) {
      console.log("response :>> ", response);
      console.log(
        `http://localhost:5001/api/products/${restorant.name}/${activeCategory}`
      );
      setItems([...response.data]);
      setIsLoading(false);
    })
    .catch(function (error) {
      console.log("error :>> ", error);
    });
};
const takeOrder = (obj, setOrderIsDone) => {
  axios
    .post(`http://localhost:5001/api/orders`, obj)
    .then(function (response) {
      console.log("obj :>> ", obj);
      console.log("data :>> ", response.data);
      if (response.data.status === 200) {
        setOrderIsDone(true);
      }
    })
    .catch(function (error) {
      // setError("Неправильный логин или пароль");
    });
};
export {
  authUser,
  getRestorants,
  getRestorantsByName,
  getProducts,
  tokenValidation,
  takeOrder,
};
