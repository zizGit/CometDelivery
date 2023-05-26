import React from "react";
import ContentLoader from "react-content-loader";

const Skeleton = (props) => (
  <ContentLoader
    speed={2}
    width={234}
    height={150}
    viewBox="0 0 234 150"
    backgroundColor="#f3f3f3"
    foregroundColor="#ecebeb"
    {...props}
  >
    <rect x="110" y="10" rx="10" ry="10" width="110" height="22" />
    <circle cx="209" cy="121" r="11" />
    <rect x="10" y="10" rx="10" ry="10" width="90" height="90" />
    <rect x="10" y="110" rx="10" ry="10" width="90" height="25" />
  </ContentLoader>
);

export default Skeleton;
