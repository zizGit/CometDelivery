import React, { useEffect } from "react";
import PartnerBlock from "../components/PartnerBlock";
export default function PartnerPage() {
  useEffect(() => {
    window.scrollTo(0, 0);
  }, []);
  return <PartnerBlock />;
}
