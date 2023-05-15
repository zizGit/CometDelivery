import React from "react";
import ContentLoader from "react-content-loader";

const Skeleton = (props) => (
  <ContentLoader
    speed={2}
    width={320}
    height={230}
    viewBox="0 0 320 230"
    backgroundColor="#f3f3f3"
    foregroundColor="#ecebeb"
    {...props}
  >
    <rect x="167" y="425" rx="0" ry="0" width="12" height="2" />
    <rect x="0" y="0" rx="20" ry="20" width="320" height="180" />
    <rect x="25" y="195" rx="10" ry="10" width="110" height="25" />
    <rect x="200" y="195" rx="10" ry="10" width="90" height="25" />
  </ContentLoader>
);

export default Skeleton;
