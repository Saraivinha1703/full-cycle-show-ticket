import { ZodIssue } from "zod";

export type ValidationErrorTypes = { zod?: ZodIssue[]; server?: string[] };
