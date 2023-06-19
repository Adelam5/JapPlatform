import useProfile from "./useProfile";
import PersonalProgramTable from "./PersonalProgramTable";
import StudentProgramDetails from "./StudentProgramDetails";

const Profile = () => {
  const { data } = useProfile();

  return (
    <div>
      <h3 className="text-center my-5">
        Student Profile: {data?.firstName} {data?.lastName}
      </h3>
      <StudentProgramDetails student={data} />
      <h5 className="text-center my-3">Personal Program</h5>
      <PersonalProgramTable items={data?.personalProgram} />
    </div>
  );
};

export default Profile;
