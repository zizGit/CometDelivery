import React from "react";
import styles from "./Restorant.module.scss";
import RestorantImg from "../../assets/Establishment/image 13.png";
import { Link } from "react-router-dom";

export default function RestorantBlock() {
  return (
    <div className={styles.container}>
      <div className={styles.container__top}>
        <Link to="/establishment/restorant">
          <img src={RestorantImg} alt="" />
          <div className={styles.container__about}>
            <h3>Name</h3>
            <div className={styles.container__categories}>
              <p>American</p>
              <p>Pizza</p>
              <p>Sushi</p>
            </div>
          </div>
        </Link>
      </div>
      <div className={styles.container__bottom}>
        <div className={styles.delivery}>
          <svg
            width="29"
            height="21"
            viewBox="0 0 29 21"
            fill="none"
            xmlns="http://www.w3.org/2000/svg"
          >
            <path
              d="M5.39075 18.4787C5.26933 18.4787 5.17091 18.3786 5.17091 18.2551C5.17091 18.1316 5.26933 18.0315 5.39075 18.0315C5.51217 18.0315 5.6106 18.1316 5.6106 18.2551C5.6106 18.3786 5.51217 18.4787 5.39075 18.4787Z"
              fill="#040B20"
            />
            <path
              d="M3.55742 8.63344C3.3207 8.47125 3.16414 8.19516 3.16414 7.88297V6.08063C3.16414 5.58469 3.55883 5.19375 4.04211 5.21062L14.5899 5.59781C15.0737 5.61469 15.4688 6.03516 15.4688 6.53156V7.88297C15.4688 8.37891 15.0732 8.78484 14.5899 8.78484H14.0457L13.5591 9.27703C13.5282 9.30984 12.6671 10.2427 12.6671 12.1833C12.6671 13.058 13.4762 13.7695 14.4699 13.7695H18.0015C18.3137 13.4264 18.8598 11.6873 18.8598 8.79C18.8598 5.81625 17.7371 4.29234 17.7259 4.27734L17.4985 3.975L17.2501 4.08C17.0977 4.155 16.9173 4.16906 16.7513 4.09078C16.457 3.94969 16.3295 3.59437 16.4668 3.29344C16.5172 3.18984 16.5975 3.10377 16.6974 3.04641L17.5988 2.65547C17.6705 2.07844 18.0741 1.61766 18.6151 1.52906C18.7224 1.51125 18.8485 1.43109 18.8579 1.39547C19.1016 0.469218 19.7232 0 20.7038 0H22.0562L22.066 0.714844H22.547V1.16156C22.8962 1.16156 23.1798 1.66125 23.1798 2.27859C23.1798 2.89453 22.8966 3.39562 22.547 3.39562V3.84234H22.0665V4.55719H21.1215C22.2652 6.23812 24.1566 9.31125 24.1566 11.2627C24.1566 11.3466 24.1487 11.4305 24.1351 11.5134C25.749 11.7305 27.2218 12.712 28.0046 14.1352C28.1584 14.4141 28.1654 14.7267 28.0243 14.9925C27.8035 15.4092 27.3591 15.5438 26.6696 15.6202C26.8663 16.0715 26.9683 16.5584 26.9691 17.0508C26.9691 19.0247 25.3955 20.625 23.4535 20.625C21.662 20.625 20.1863 19.2619 19.9688 17.5003H18.894C18.7815 17.5003 18.6891 17.5463 18.5077 17.6423C18.2527 17.7769 17.903 17.9611 17.3973 17.9611H8.78492C8.38883 19.4934 7.02148 20.625 5.3907 20.625C3.75945 20.625 2.39258 19.4934 1.99648 17.9606H7.62939e-05V17.2463C7.62939e-05 12.7069 2.51539 9.68906 3.55742 8.63344ZM14.9795 6.49078C14.9949 6.49172 15.008 6.49922 15.0235 6.50063C15.0071 6.25875 14.8112 6.05297 14.5749 6.04359L4.01117 5.65734C3.78242 5.65734 3.60383 5.84344 3.60383 6.08063V6.10406L14.9795 6.49078ZM23.4535 18.8381C24.4248 18.8381 25.2113 18.0375 25.2113 17.0508C25.2113 16.5605 25.0135 16.1217 24.698 15.8002C24.3263 15.8522 23.9926 15.9248 23.7948 16.0336C23.5623 16.1616 23.3546 16.3195 23.1348 16.4869C22.929 16.6434 22.711 16.8061 22.4649 16.9547C22.4816 16.9883 22.4895 17.0256 22.4878 17.0631C22.4861 17.1005 22.4749 17.137 22.4553 17.1689C22.4357 17.2009 22.4082 17.2274 22.3755 17.2458C22.3429 17.2642 22.306 17.2741 22.2685 17.2744C22.187 17.2744 22.119 17.2275 22.081 17.1609C21.968 17.213 21.849 17.2617 21.7205 17.3039C21.8424 18.1697 22.568 18.8381 23.4535 18.8381ZM5.3907 18.8381C6.03195 18.8381 6.5832 18.4833 6.88836 17.9611H6.43601C6.42726 17.9984 6.40901 18.0328 6.38305 18.0609C6.36293 18.0818 6.33883 18.0984 6.31217 18.1097C6.28551 18.121 6.25685 18.1268 6.22789 18.1268C6.19893 18.1268 6.17026 18.121 6.1436 18.1097C6.11695 18.0984 6.09284 18.0818 6.07273 18.0609C6.04644 18.033 6.02814 17.9985 6.01976 17.9611H4.7607C4.75195 17.9984 4.7337 18.0328 4.70773 18.0609C4.68762 18.0818 4.66352 18.0984 4.63686 18.1097C4.6102 18.121 4.58154 18.1268 4.55258 18.1268C4.52361 18.1268 4.49495 18.121 4.46829 18.1097C4.44164 18.0984 4.41753 18.0818 4.39742 18.0609C4.37112 18.033 4.35283 17.9985 4.34445 17.9611H3.89258C4.19773 18.4833 4.74898 18.8381 5.3907 18.8381ZM17.3973 17.2463C18.0502 17.2463 18.302 16.7855 18.894 16.7855H20.401C22.0388 16.7855 22.4921 15.9394 23.4596 15.405C24.6057 14.7731 27.7646 15.1631 27.391 14.4848C26.6359 13.1114 25.0749 12.1838 23.4596 12.1838C23.333 12.1838 23.2088 12.1927 23.0851 12.2039L23.086 12.2025C23.086 12.2025 23.453 11.6658 23.453 11.2631C23.453 8.79047 19.7462 3.84281 19.7462 3.84281H21.3629V0.715312H20.7038C20.3424 0.715312 19.757 0.744843 19.5366 1.58109C19.4354 1.965 19.058 2.15719 18.7988 2.21953C19.0543 2.36063 19.2291 2.63203 19.2291 2.94844C19.2291 3.40875 18.8626 3.78281 18.4098 3.78281C18.3676 3.78281 18.3273 3.77672 18.287 3.76969V3.84328H18.2841C18.2841 3.84328 19.5634 5.54016 19.5634 8.79094C19.5634 11.9386 18.9095 14.4853 18.1023 14.4853H14.4704C13.0848 14.4853 11.9645 13.4569 11.9645 12.1842C11.9645 10.0341 12.9245 8.92219 13.0501 8.78578H4.42789C4.24695 8.94094 0.703201 12.052 0.703201 17.2472H17.3973V17.2463Z"
              fill="#040B20"
            />
            <path
              d="M6.9957 9.71587C7.60273 9.66009 8.23789 9.67509 8.84586 9.84431C9.45101 10.014 10.0252 10.3252 10.4855 10.7677C10.9407 11.2116 11.2904 11.7713 11.4652 12.3807C11.6421 12.9854 11.686 13.6212 11.5941 14.2445C11.4972 14.8521 11.2895 15.4368 10.9815 15.9695C11.4245 14.8473 11.5501 13.5859 11.1446 12.4918C10.7527 11.3973 9.82883 10.5587 8.73055 10.2751C8.18492 10.1152 7.60976 10.0974 7.02945 10.1368C6.45101 10.1748 5.87773 10.291 5.31664 10.457C4.75555 10.6234 4.21086 10.8568 3.68961 11.1376C3.16226 11.4095 2.66258 11.7376 2.19195 12.1126C3.01789 11.2276 4.06883 10.5596 5.21023 10.1321C5.7807 9.91181 6.38492 9.7829 6.9957 9.71587Z"
              fill="#040B20"
            />
            <path
              d="M6.43608 10.5863C7.00562 10.5268 7.59624 10.5268 8.17655 10.6449C8.75311 10.7668 9.31468 11.0025 9.79233 11.3672C10.2639 11.7347 10.6558 12.2232 10.87 12.7875C11.0844 13.3463 11.1541 13.9501 11.0725 14.543C10.9833 15.1176 10.7753 15.6672 10.4617 16.1569C10.9197 15.1186 11.0312 13.9097 10.5597 12.9249C10.1017 11.9382 9.13702 11.2819 8.08937 11.0818C7.56765 10.9664 7.02108 10.9636 6.47359 11.0063C5.92702 11.0414 5.38702 11.1516 4.85312 11.2908C4.32015 11.4361 3.8003 11.6363 3.29968 11.88C2.78968 12.1165 2.30288 12.4001 1.84562 12.7271C2.65936 11.9297 3.6728 11.3452 4.75421 10.9646C5.29828 10.7737 5.8627 10.6468 6.43608 10.5863ZM21.8758 12.6249C22.5747 12.4341 23.3165 12.4729 23.9917 12.7355C24.6557 12.9846 25.2239 13.4372 25.615 14.0288C25.1217 13.5774 24.5294 13.248 23.8858 13.0669C23.2614 12.8944 22.6042 12.8808 21.9925 13.0557C21.378 13.2197 20.8187 13.5741 20.3664 14.0424C19.9061 14.5346 19.5682 15.1283 19.3801 15.7754C19.4102 15.0608 19.6653 14.374 20.1091 13.8132C20.5578 13.2405 21.1762 12.8246 21.8758 12.6249Z"
              fill="#040B20"
            />
            <path
              d="M24.639 17.2743C24.5176 17.2743 24.4192 17.1742 24.4192 17.0507C24.4192 16.9273 24.5176 16.8271 24.639 16.8271C24.7605 16.8271 24.8589 16.9273 24.8589 17.0507C24.8589 17.1742 24.7605 17.2743 24.639 17.2743Z"
              fill="#040B20"
            />
            <path
              d="M24.4468 17.7439C24.4883 17.7863 24.5115 17.8431 24.5115 17.9024C24.5115 17.9616 24.4883 18.0185 24.4468 18.0608C24.3615 18.1485 24.2223 18.1485 24.1365 18.0608C24.0507 17.9732 24.0502 17.8321 24.1365 17.7439C24.1567 17.7232 24.1808 17.7068 24.2074 17.6955C24.2341 17.6843 24.2627 17.6785 24.2916 17.6785C24.3206 17.6785 24.3492 17.6843 24.3758 17.6955C24.4025 17.7068 24.4266 17.7232 24.4468 17.7439Z"
              fill="#040B20"
            />
            <path
              d="M23.4545 18.4787C23.3331 18.4787 23.2346 18.3786 23.2346 18.2551C23.2346 18.1316 23.3331 18.0315 23.4545 18.0315C23.5759 18.0315 23.6743 18.1316 23.6743 18.2551C23.6743 18.3786 23.5759 18.4787 23.4545 18.4787Z"
              fill="#040B20"
            />
            <path
              d="M22.7715 17.7445C22.8578 17.8316 22.8578 17.9727 22.7715 18.0604C22.6853 18.1481 22.5465 18.1481 22.4612 18.0604C22.4194 18.0185 22.3959 17.9617 22.3959 17.9024C22.3959 17.8432 22.4194 17.7864 22.4612 17.7445C22.4815 17.7239 22.5056 17.7075 22.5322 17.6963C22.5589 17.6851 22.5875 17.6794 22.6164 17.6794C22.6453 17.6794 22.6739 17.6851 22.7005 17.6963C22.7271 17.7075 22.7513 17.7239 22.7715 17.7445ZM24.4468 16.041C24.4885 16.0829 24.512 16.1396 24.512 16.1988C24.512 16.2579 24.4885 16.3146 24.4468 16.3565C24.3606 16.4441 24.2218 16.4441 24.1356 16.3565C24.0943 16.3144 24.0712 16.2577 24.0712 16.1988C24.0712 16.1398 24.0943 16.0832 24.1356 16.041C24.1558 16.0201 24.1799 16.0035 24.2067 15.9921C24.2334 15.9807 24.2622 15.9749 24.2912 15.9749C24.3203 15.9749 24.349 15.9807 24.3758 15.9921C24.4025 16.0035 24.4267 16.0201 24.4468 16.041Z"
              fill="#040B20"
            />
            <path
              d="M23.4536 17.4974C23.2108 17.4974 23.0139 17.2974 23.0139 17.0507C23.0139 16.804 23.2108 16.604 23.4536 16.604C23.6965 16.604 23.8933 16.804 23.8933 17.0507C23.8933 17.2974 23.6965 17.4974 23.4536 17.4974Z"
              fill="#040B20"
            />
          </svg>
          39.00 ₴
        </div>
        <p>20-30 min</p>
      </div>
    </div>
  );
}
