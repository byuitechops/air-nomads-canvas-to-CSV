namespace CanvasCoursestring
{
    public class CanvasCourse
    {
        public double id { get; set; }
        public string sis_course_id { get; set; }
        public string uuid { get; set; }
        public string integration_id { get; set; }
        public double sis_import_id { get; set; }
        public string name { get; set; }
        public string course_code { get; set; }
        public string workflow_state { get; set; }
        public double account_id { get; set; }
        public double root_account_id { get; set; }
        public double enrollment_term_id { get; set; }
        public double grading_standard_id { get; set; }
        public string created_at { get; set; }
        public string start_at { get; set; }
        public string end_at { get; set; }
        public string locale { get; set; }
        public string enrollments { get; set; }
        public double total_students { get; set; }
        public string calendar { get; set; }
        public string default_view { get; set; }
        public string syllabus_body { get; set; }
        public double needs_grading_count { get; set; }
        public string term { get; set; }
        public string course_progress { get; set; }
        public bool apply_assignment_group_weights { get; set; }
        public string permissions { get; set; }
        public bool is_public { get; set; }
        public bool is_public_to_auth_users { get; set; }
        public bool public_syllabus { get; set; }
        public bool public_syllabus_to_auth { get; set; }
        public string public_description { get; set; }
        public double storage_quota_mb { get; set; }
        public double storage_quota_used_mb { get; set; }
        public bool hide_final_grades { get; set; }
        public string license { get; set; }
        public bool allow_student_assignment_edits { get; set; }
        public bool allow_wiki_comments { get; set; }
        public bool allow_student_forum_attachments { get; set; }
        public bool open_enrollment { get; set; }
        public bool self_enrollment { get; set; }
        public bool restrict_enrollments_to_course_dates { get; set; }
        public string course_format { get; set; }
        public bool access_restricted_by_date { get; set; }
        public string time_zone { get; set; }
        public bool blueprint { get; set; }
        public string blueprint_restrictions { get; set; }
        public string blueprint_restrictions_by_string_type { get; set; }
    }
}