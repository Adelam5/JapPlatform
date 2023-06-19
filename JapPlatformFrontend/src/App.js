import { Route, Routes } from "react-router-dom";

import Sidebar from "components/Sidebar/Sidebar";
import {
  Login,
  Programs,
  SelectionDetails,
  SelectionEdit,
  SelectionNew,
  Selections,
  StudentDetails,
  StudentEdit,
  StudentNew,
  Students,
} from "pages";

import RequireAuth from "RequireAuth";
import StudentProfile from "pages/Students/StudentProfile";
import Dashboard from "pages/Admin/Dashboard";
import ProgramDetails from "pages/Programs/ProgramDetails";
import ProgramNew from "pages/Programs/ProgramNew";
import ProgramEdit from "pages/Programs/ProgramEdit";
import Lectures from "pages/Lectures/Lectures";
import LectureNew from "pages/Lectures/LectureNew";
import LectureDetails from "pages/Lectures/LectureDetails";
import LectureEdit from "pages/Lectures/LectureEdit";

const App = () => {
  return (
    <>
      <Routes>
        <Route path="/" element={<Login />} />
        <Route element={<RequireAuth allowedRoles={["Admin"]} />}>
          <Route element={<Sidebar />}>
            <Route path="/dashboard" element={<Dashboard />} />

            <Route path="/programs" element={<Programs />} />
            <Route path="/programs/new" element={<ProgramNew />} />
            <Route path="/programs/:programId" element={<ProgramDetails />} />
            <Route path="/programs/:programId/edit" element={<ProgramEdit />} />

            <Route path="/students" element={<Students />} />
            <Route path="/students/new" element={<StudentNew />} />
            <Route path="/students/:studentId" element={<StudentDetails />} />
            <Route path="/students/:studentId/edit" element={<StudentEdit />} />

            <Route path="/selections" element={<Selections />} />
            <Route path="/selections/new" element={<SelectionNew />} />
            <Route
              path="/selections/:selectionId"
              element={<SelectionDetails />}
            />
            <Route
              path="/selections/:selectionId/edit"
              element={<SelectionEdit />}
            />

            <Route path="/lectures" element={<Lectures />} />
            <Route path="/lectures/new" element={<LectureNew />} />
            <Route path="/lectures/:lectureId" element={<LectureDetails />} />
            <Route path="/lectures/:lectureId/edit" element={<LectureEdit />} />
          </Route>
        </Route>
        <Route element={<RequireAuth allowedRoles={["Student"]} />}>
          <Route path="/profile" element={<StudentProfile />} />
        </Route>
      </Routes>
    </>
  );
};

export default App;
