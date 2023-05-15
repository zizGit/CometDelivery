import React from "react";
import styles from "./PartnervBlock.module.scss";
// import BackGround from "../../assets/Partner/BackGround.svg";
import PartnerPhoto from "../../assets/Partner/PartnerPhoto.png";
import { useEffect } from "react";
export default function PartnerPage() {
  useEffect(() => {
    window.scrollTo(0, 0);
  }, []);
  return (
    <div className={styles.wrapper}>
      <h2 className={styles.start}>
        Start your online business journey with Comet
      </h2>
      <div className={styles.main}>
        <div className={styles.main__block}>
          <p className={styles.main__pointed}>
            Register to become our partner. Start the process of digital
            transformation of your company today
          </p>
          <form className={styles.main__form}>
            <h2>Start Selling at Comet</h2>
            <p>
              Registering with Сomet is a matter of a few minutes. Become our
              partner today
            </p>
            <label for="adress">
              Adress
              <input type="text" id="adress" />
            </label>
            <label for="business_name">
              Business Name
              <input type="text" id="business_name" />
            </label>
            <div className={styles.form__names}>
              <label for="first_name">
                First Name
                <input type="text" id="first_name" />
              </label>
              <label for="last_name">
                Last Name
                <input type="text" id="last_name" />
              </label>
            </div>
            <label for="email">
              Email
              <input type="email" id="email" />
            </label>
            <label for="phone_number">
              Phone number
              <input type="email" id="phone_number" />
            </label>
            <p>
              Check out our <a href=".">privacy policy</a>
            </p>
            <button type="submit">Become a partner</button>
          </form>
        </div>
        <div className={styles.second__block}>
          <img src={PartnerPhoto} alt="1234" />
          <p className={styles.second__pointed}>
            Our mission is to help thousands of local businesses find their
            niche in today's digital economy
          </p>
        </div>
      </div>
    </div>
  );
}
