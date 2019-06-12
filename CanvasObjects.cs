using System;
using System.Collections.Generic;
namespace CanvasObjects {
	 
public class Permissions
{
    public bool create_discussion_topic { get; set; }
    public bool create_announcement { get; set; }
}

public class BlueprintRestrictions
{
    public bool content { get; set; }
    public bool points { get; set; }
    public bool due_dates { get; set; }
    public bool availability_dates { get; set; }
}

public class Assignment
{
    public bool content { get; set; }
    public bool points { get; set; }
}

public class WikiPage
{
    public bool content { get; set; }
}

public class BlueprintRestrictionsByObjectType
{
    public Assignment assignment { get; set; }
    public WikiPage wiki_page { get; set; }
}

public class CourseObject
{
    public int id { get; set; }
    public object sis_course_id { get; set; }
    public string uuid { get; set; }
    public object integration_id { get; set; }
    public int sis_import_id { get; set; }
    public string name { get; set; }
    public string course_code { get; set; }
    public string workflow_state { get; set; }
    public int account_id { get; set; }
    public int root_account_id { get; set; }
    public int enrollment_term_id { get; set; }
    public int grading_standard_id { get; set; }
    public DateTime created_at { get; set; }
    public DateTime start_at { get; set; }
    public DateTime end_at { get; set; }
    public string locale { get; set; }
    public object enrollments { get; set; }
    public int total_students { get; set; }
    public object calendar { get; set; }
    public string default_view { get; set; }
    public string syllabus_body { get; set; }
    public int needs_grading_count { get; set; }
    public object term { get; set; }
    public object course_progress { get; set; }
    public bool apply_assignment_group_weights { get; set; }
    public Permissions permissions { get; set; }
    public bool is_public { get; set; }
    public bool is_public_to_auth_users { get; set; }
    public bool public_syllabus { get; set; }
    public bool public_syllabus_to_auth { get; set; }
    public string public_description { get; set; }
    public int storage_quota_mb { get; set; }
    public int storage_quota_used_mb { get; set; }
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
    public List<int> itemz { get; set; }
    public BlueprintRestrictions blueprint_restrictions { get; set; }
    public BlueprintRestrictionsByObjectType blueprint_restrictions_by_object_type { get; set; }
}
	
}