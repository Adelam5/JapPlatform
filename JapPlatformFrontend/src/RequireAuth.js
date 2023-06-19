import { Navigate, Outlet, useLocation } from "react-router-dom";

import SpinnerCenter from "components/Spinner/SpinnerCenter";

import { useCurrentUser } from "features/Auth/useCurrentUser";

const RequireAuth = ({ allowedRoles }) => {
  const { data: user, isLoading } = useCurrentUser();

  const location = useLocation();

  if (isLoading) {
    return <SpinnerCenter />;
  }

  return allowedRoles.includes(user?.role) ? (
    <Outlet />
  ) : (
    <Navigate to="/" state={{ from: location }} replace />
  );
};

export default RequireAuth;
