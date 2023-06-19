import { NavLink } from "react-router-dom";

const SidebarLink = ({ to, label }) => {
  return (
    <NavLink className="w-100" to={to}>
      {label}
    </NavLink>
  );
};

export default SidebarLink;
